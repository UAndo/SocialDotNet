import React from 'react';
import { Tab, TabGroup, TabList, TabPanel, TabPanels } from '@headlessui/react';
import ItemList from './ItemList';

interface Item {
    id: number;
    title: string;
    date: string;
}

interface TabContentProps {
    entityType: string;
    data: Item[];
    setSelectedItem: (item: Item) => void;
}

const TabContent: React.FC<TabContentProps> = ({ entityType, data, setSelectedItem }) => {
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
                            <ItemList data={data} setSelectedItem={setSelectedItem} />
                        </TabPanel>
                    </TabPanels>
                </TabGroup>
            </div>
        </div>
    );
};

export default TabContent;
