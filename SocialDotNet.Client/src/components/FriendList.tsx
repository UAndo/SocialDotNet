import React from 'react';

interface Friend {
    id: number;
    name: string;
    status: string;
}

interface FriendListProps {
    data: Friend[];
    setSelectedFriend: (friend: Friend) => void;
}

const FriendList: React.FC<FriendListProps> = ({ data, setSelectedFriend }) => {
    return (
        <div>
            <ul>
                {data.map((friend) => (
                    <li
                        key={friend.id}
                        className="relative rounded-md dark:bg-black/5 bg-white p-3 mb-3 text-sm transition hover:bg-black/10"
                        onClick={() => setSelectedFriend(friend)}
                        role="button"
                        tabIndex={0}
                        onKeyDown={(e) => {
                            if (e.key === 'Enter' || e.key === ' ') {
                                setSelectedFriend(friend);
                            }
                        }}
                    >
                        <a href="#" className="font-semibold dark:text-white text-black">
                            <span className="absolute inset-0" />
                            {friend.name}
                        </a>
                        <ul className="flex gap-2 dark:text-white/50 text-slate-500" aria-hidden="true">
                            <li>{friend.status}</li>
                            <li aria-hidden="true">&middot;</li>
                        </ul>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default FriendList;
