import React from 'react';
import { Tab, TabGroup, TabList, TabPanel, TabPanels } from '@headlessui/react';

interface Chat {
    id: number;
    title: string;
    date: string;
}

interface ChatTabsProps {
    entityType: string;
    data: Chat[];
    setSelectedChat: (chat: Chat) => void;
}

const ChatTabs: React.FC<ChatTabsProps> = ({ entityType, data, setSelectedChat }) => {
    return (
        <div className="flex w-full justify-center">
            <div className="w-full max-w-md">
                <TabGroup>
                    <TabList className="flex gap-4">
                        <Tab
                            className="rounded-full py-1 px-3 text-sm/6 font-semibold dark:text-white text-black focus:outline-none dark:data-[selected]:bg-black/10 data-[selected]:bg-white data-[hover]:bg-black/5 data-[selected]:data-[hover]:bg-black/10 data-[focus]:outline-1 data-[focus]:outline-black"
                        >
                            {entityType.charAt(0).toUpperCase() + entityType.slice(1)}
                        </Tab>
                    </TabList>
                    <TabPanels className="mt-3 h-[74vh]">
                        <TabPanel className="rounded-xl p-3 h-full overflow-y-auto">
                            <ul>
                                {data.map((item) => (
                                    <li 
                                        key={item.id} 
                                        className="relative rounded-md dark:bg-black/5 bg-white p-3 mb-3 text-sm/6 transition hover:bg-black/10" 
                                        onClick={() => setSelectedChat(item)}
                                        role="button"
                                        tabIndex={0}
                                        onKeyDown={(e) => {
                                            if (e.key === 'Enter' || e.key === ' ') {
                                                setSelectedChat(item);
                                            }
                                        }}
                                    >
                                        <a href="#" className="font-semibold dark:text-white text-black">
                                            <span className="absolute inset-0" />
                                            {item.title}
                                        </a>
                                        <ul className="flex gap-2 dark:text-white/50 text-slate-500" aria-hidden="true">
                                            <li>{item.date}</li>
                                            <li aria-hidden="true">&middot;</li>
                                        </ul>
                                    </li>
                                ))}
                            </ul>
                        </TabPanel>
                    </TabPanels>
                </TabGroup>
            </div>
        </div>
    );
};

export default ChatTabs;

