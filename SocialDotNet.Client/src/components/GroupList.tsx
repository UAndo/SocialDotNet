import React from 'react';

interface Group {
    id: number;
    name: string;
    members: number;
}

interface GroupListProps {
    data: Group[];
    setSelectedGroup: (group: Group) => void;
}

const GroupList: React.FC<GroupListProps> = ({ data, setSelectedGroup }) => {
    return (
        <div>
            <ul>
                {data.map((group) => (
                    <li
                        key={group.id}
                        className="relative rounded-md dark:bg-black/5 bg-white p-3 mb-3 text-sm transition hover:bg-black/10"
                        onClick={() => setSelectedGroup(group)}
                        role="button"
                        tabIndex={0}
                        onKeyDown={(e) => {
                            if (e.key === 'Enter' || e.key === ' ') {
                                setSelectedGroup(group);
                            }
                        }}
                    >
                        <a href="#" className="font-semibold dark:text-white text-black">
                            <span className="absolute inset-0" />
                            {group.name}
                        </a>
                        <ul className="flex gap-2 dark:text-white/50 text-slate-500" aria-hidden="true">
                            <li>{group.members} members</li>
                            <li aria-hidden="true">&middot;</li>
                        </ul>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default GroupList;
