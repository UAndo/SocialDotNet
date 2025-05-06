import React, { useState } from 'react';

interface DialogProps {
    userName: string;
    lastOnline: string;
    messages: Message[];
}

interface Message {
    id: string;
    sender: User;
    text: string;
    timestamp: Date;
  }

function MessageTextarea({ messages }) {
    const [newMessage, setNewMessage] = useState('');

    const handleMessageChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setNewMessage(e.target.value);
    };

    const handleSendMessage = (e: React.MouseEvent<HTMLInputElement>) => {
        if (newMessage.trim() === '') {
            return;
        }
        const updatedMessages = [...messages, { content: newMessage, isSent: true }];
        messages.push({ content: newMessage, isSent: true });
        console.log('���� �����������:', newMessage);
        setNewMessage('');
        let textArea = event?.target;
        console.log(textArea.style.height);
        textArea.style.height = '10px ';
        console.log(textArea.style.height);
        textArea.rows = "1";
    };

    const handleKeyDown = (e: React.KeyboardEvent<HTMLInputElement>) => {
        AutoResizeTextarea();
        if (e.key === 'Enter') {
            handleSendMessage();
        }
    };

    function AutoResizeTextarea() {
        const textarea = document.querySelector('textarea');

        textarea.addEventListener('input', function () {
            this.style.height = 'auto';
            this.style.height = (this.scrollHeight) + 'px';
        });
    }

    return (
        <div className="flex items-end dark:bg-gray-800 bg-gray-100 w-full">
            <button className="py-2 px-2 dark:text-white rounded dark:bg-gray-800 hover:dark:bg-gray-700 bg-gray-100 hover:bg-gray-200 h-10 dark:text-white text-black">
                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                    <path strokeLinecap="round" strokeLinejoin="round" d="m18.375 12.739-7.693 7.693a4.5 4.5 0 0 1-6.364-6.364l10.94-10.94A3 3 0 1 1 19.5 7.372L8.552 18.32m.009-.01-.01.01m5.699-9.941-7.81 7.81a1.5 1.5 0 0 0 2.112 2.13" />
                </svg>
            </button>
            <div className="input-panel flex w-full max-h-[50vh] overflow-y-auto rounded-lg dark:bg-gray-800 bg-gray-200">
                <textarea
                    type="text"
                    rows="1"
                    className="flex-1 p-2 dark:bg-gray-800 bg-gray-100 focus:outline-none dark:caret-white caret-black dark:text-white text-slate-500 resize-none text-sm/6"
                    placeholder="Type your message..."
                    value={newMessage}
                    onChange={handleMessageChange}
                    onKeyDown={handleKeyDown}
                />
            </div>
            <button
                className="py-2 px-2 dark:text-white rounded dark:bg-gray-800 hover:dark:bg-gray-700 bg-gray-100 hover:bg-gray-200 h-10 dark:text-white text-black"
                onClick={handleSendMessage}
            >
                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" className="size-6">
                    <path strokeLinecap="round" strokeLinejoin="round" d="M6 12 3.269 3.125A59.769 59.769 0 0 1 21.485 12 59.768 59.768 0 0 1 3.27 20.875L5.999 12Zm0 0h7.5" />
                </svg>
            </button>
            <button
                className="py-2 px-2 dark:text-white rounded dark:bg-gray-800 hover:dark:bg-gray-700 bg-gray-100 hover:bg-gray-200 h-10 mr-2 dark:text-white text-black"
                onClick={handleSendMessage}
            >
                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                    <path strokeLinecap="round" strokeLinejoin="round" d="M15.182 15.182a4.5 4.5 0 0 1-6.364 0M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0ZM9.75 9.75c0 .414-.168.75-.375.75S9 10.164 9 9.75 9.168 9 9.375 9s.375.336.375.75Zm-.375 0h.008v.015h-.008V9.75Zm5.625 0c0 .414-.168.75-.375.75s-.375-.336-.375-.75.168-.75.375-.75.375.336.375.75Zm-.375 0h.008v.015h-.008V9.75Z" />
                </svg>
            </button>
        </div>
    )
}

export default MessageTextarea;