import React, { useState } from 'react';
import MessageItem from './MessageItem'
import MessageTextarea from './MessageTextarea';
interface DialogProps {
    userName: string;
    lastOnline: string;
    messages: Message[];
}

type Message = {
    content: string;
    isSent: boolean;
};

function Dialog({ userName, lastOnline, messages }: DialogProps ) {
    const [newMessage, setNewMessage] = useState('');

    const handleMessageChange = (e) => {
        setNewMessage(e.target.value);
    };

    const handleSendMessage = () => {
        console.log('Sending message:', newMessage);
        messages.push({ content: newMessage, isSent: true });
        setNewMessage('');
    };

    const handleKeyDown = (e) => {
        if (e.key === 'Enter') {
            handleSendMessage(); 
        }
    };

    return (
        <div className="flex flex-col h-full">
            <div className="dialog-header dark:bg-darkBlue bg-gray-100 p-4 text-sm/6">
                <h2 className="text-white font-semibold">{userName}</h2>
                <p className="text-white/50">Last online: {lastOnline}</p>
            </div>
            <div className="dialog-container h-full bg-gray-100 p-4 shadow-md dark:bg-darkBlue overflow-y-auto">
                <div className="messages-container mb-4">
                    {messages.map((message: Message, index: int) => (
                        <MessageItem
                            content={message.content}
                            isSent={message.isSent}
                         />
                    ))}
                </div>
            </div>
            <div className="input-panel flex w-full">
                <MessageTextarea value={newMessage} onChange={handleMessageChange} onKeyDown={handleKeyDown} />
            </div>
        </div>
    );
}

export default Dialog;
