import React, { useEffect, useState, useRef } from 'react';
import { HubConnectionBuilder, HubConnection } from '@microsoft/signalr';

interface Message {
  messageId: string;
  senderId: string;
  content: string;
  sentAt: string;
}

interface ChatViewProps {
  chatId: string;
  currentUserId: string;
}

const ChatView: React.FC<ChatViewProps> = ({ chatId, currentUserId }) => {
  const [messages, setMessages] = useState<Message[]>([]);
  const [input, setInput] = useState('');
  const [connection, setConnection] = useState<HubConnection | null>(null);
  const messagesEndRef = useRef<HTMLDivElement>(null);

  // Scroll to bottom on new message
  useEffect(() => {
    messagesEndRef.current?.scrollIntoView({ behavior: 'smooth' });
  }, [messages]);

  // SignalR connection setup
  useEffect(() => {
    const newConnection = new HubConnectionBuilder()
      .withUrl('/chathub')
      .withAutomaticReconnect()
      .build();

    setConnection(newConnection);
  }, [chatId]);

  useEffect(() => {
    if (connection) {
      connection.start()
        .then(() => {
          connection.invoke('JoinChat', chatId);
          connection.on('ReceiveMessage', (message: any) => {
            setMessages(prev => [...prev, message]);
          });
        });
      return () => {
        connection.invoke('LeaveChat', chatId);
        connection.stop();
      };
    }
  }, [connection, chatId]);

  // Load chat history
  useEffect(() => {
    fetch(`/messages/get-by-chat/${chatId}`)
      .then(res => res.json())
      .then(data => setMessages(data));
  }, [chatId]);

  const sendMessage = async () => {
    if (!input.trim()) return;
    await fetch('/messages/send', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ chatId, senderId: currentUserId, content: input })
    });
    setInput('');
  };

  return (
    <div className="flex flex-col h-full">
      <div className="flex-1 overflow-y-auto p-4 bg-gray-100">
        {messages.map(msg => (
          <div key={msg.messageId} className={`message ${msg.senderId === currentUserId ? 'sent' : ''}`}>
            <div><b>{msg.senderId === currentUserId ? 'Ви' : msg.senderId}</b></div>
            <div>{msg.content}</div>
            <div className="text-xs text-gray-400">{new Date(msg.sentAt).toLocaleTimeString()}</div>
          </div>
        ))}
        <div ref={messagesEndRef} />
      </div>
      <div className="p-2 flex gap-2 bg-white border-t">
        <input
          className="flex-1 border rounded px-2 py-1"
          value={input}
          onChange={e => setInput(e.target.value)}
          onKeyDown={e => e.key === 'Enter' && sendMessage()}
          placeholder="Введіть повідомлення..."
        />
        <button className="bg-blue-500 text-white px-4 py-1 rounded" onClick={sendMessage}>
          Надіслати
        </button>
      </div>
    </div>
  );
};

export default ChatView;
