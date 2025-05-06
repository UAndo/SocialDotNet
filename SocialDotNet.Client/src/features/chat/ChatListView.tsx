import React, { useEffect, useState } from 'react';
import ChatView from './ChatView';

interface Chat
{
    chatId: string;
    name: string;
}

interface ChatListViewProps
{
    currentUserId: string;
}

const ChatListView: React.FC<ChatListViewProps> = ({ currentUserId }) =>
{
    const [chats, setChats] = useState<Chat[]>([]);
    const [selectedChatId, setSelectedChatId] = useState<string | null>(null);

    useEffect(() =>
    {
        fetch(`/chats/user/${currentUserId}`)
            .then(res => res.json())
            .then(data => setChats(data));
    }, [currentUserId]);

    return (
        <div className="flex h-full">
            <div className="w-64 border-r bg-white p-2 overflow-y-auto">
                <h2 className="font-bold mb-2">Ваші чати</h2>
                <ul>
                    {chats.map(chat => (
                        <li
                            key={chat.chatId}
                            className={`p-2 rounded cursor-pointer mb-1 ${selectedChatId === chat.chatId ? 'bg-blue-100 font-bold' : 'hover:bg-gray-100'}`}
                            onClick={() => setSelectedChatId(chat.chatId)}
                        >
                            {chat.name}
                        </li>
                    ))}
                </ul>
            </div>
            <div className="flex-1">
                {selectedChatId ? (
                    <ChatView chatId={selectedChatId} currentUserId={currentUserId} />
                ) : (
                    <div className="flex items-center justify-center h-full text-gray-400">Оберіть чат для перегляду</div>
                )}
            </div>
        </div>
    );
};

export default ChatListView;
