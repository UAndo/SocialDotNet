import React from 'react';

interface Call {
    id: number;
    title: string;
    date: string;
}

interface CallListProps {
    data: Call[];
    setSelectedCall: (call: Call) => void;
}

const CallList: React.FC<CallListProps> = ({ data, setSelectedCall }) => {
    return (
        <div>
            <ul>
                {data.map((call) => (
                    <li
                        key={call.id}
                        className="relative rounded-md dark:bg-black/5 bg-white p-3 mb-3 text-sm transition hover:bg-black/10"
                        onClick={() => setSelectedCall(call)}
                        role="button"
                        tabIndex={0}
                        onKeyDown={(e) => {
                            if (e.key === 'Enter' || e.key === ' ') {
                                setSelectedCall(call);
                            }
                        }}
                    >
                        <a href="#" className="font-semibold dark:text-white text-black">
                            <span className="absolute inset-0" />
                            {call.title}
                        </a>
                        <ul className="flex gap-2 dark:text-white/50 text-slate-500" aria-hidden="true">
                            <li>{call.date}</li>
                            <li aria-hidden="true">&middot;</li>
                        </ul>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default CallList;
