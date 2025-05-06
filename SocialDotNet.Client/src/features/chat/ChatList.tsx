import React from 'react';

interface Chat {
    id: number;
    title: string;
    date: string;
}

interface ChatListProps {
    data: Chat[];
    setSelectedChat: (chat: Chat) => void;
}

const ChatList: React.FC<ChatListProps> = ({ data, setSelectedChat }) => {
    return (
        <div>
            <ul>
                {/* {data.map((chat) => (
                    <li
                        key={chat.id}
                        className="relative rounded-md dark:bg-black/5 bg-white p-3 mb-3 text-sm transition hover:bg-black/10"
                        onClick={() => setSelectedChat(chat)}
                        role="button"
                        tabIndex={0}
                        onKeyDown={(e) => {
                            if (e.key === 'Enter' || e.key === ' ') {
                                setSelectedChat(chat);
                            }
                        }}
                    >
                        <a href="#" className="font-semibold dark:text-white text-black">
                            <span className="absolute inset-0" />
                            {chat.title}
                        </a>
                        <ul className="flex gap-2 dark:text-white/50 text-slate-500" aria-hidden="true">
                            <li>{chat.date}</li>
                            <li aria-hidden="true">&middot;</li>
                        </ul>
                    </li>
                ))} */}
            </ul>
        </div>
    );
};

export default ChatList;
