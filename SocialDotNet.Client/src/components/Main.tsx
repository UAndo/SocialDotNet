import React, { useState, useEffect } from 'react';
import Sidebar from './Sidebar';
import httpService from '../services/httpService';
import ChatList from './ChatList';
import CallList from './CallList';
import FriendList from './FriendList';
import GroupList from './GroupList';
import ChatSearch from './ChatSearch';
import { Dialog } from '@headlessui/react';
import { Bars3Icon } from '@heroicons/react/24/outline';

// Визначення типів для різних сутностей
type Chat = { /* define chat properties */ };
type Call = { /* define call properties */ };
type Friend = { /* define friend properties */ };
type Group = { /* define group properties */ };

const Main: React.FC = () => {
    const [selectedOption, setSelectedOption] = useState<string>('chats');
    const [data, setData] = useState<Chat[] | Call[] | Friend[] | Group[]>([]);
    const [selectedItem, setSelectedItem] = useState<Chat | Call | Friend | Group | null>(null);
    const [isSidebarVisible, setIsSidebarVisible] = useState<boolean>(true);
    const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await httpService(`/${selectedOption}`);
                setData(response.data);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };

        fetchData();
    }, [selectedOption]);

    const toggleSidebar = () => {
        setIsSidebarVisible(!isSidebarVisible);
    };

    const handleItemSelect = (item: Chat | Call | Friend | Group) => {
        setSelectedItem(item);
        setIsDialogOpen(true);
    };

    const renderSelectedComponent = () => {
        switch (selectedOption) {
            case 'chats':
                return <ChatList data={data as Chat[]} setSelectedChat={handleItemSelect} />;
            case 'calls':
                return <CallList data={data as Call[]} setSelectedCall={handleItemSelect} />;
            case 'friends':
                return <FriendList data={data as Friend[]} setSelectedFriend={handleItemSelect} />;
            case 'groups':
                return <GroupList data={data as Group[]} setSelectedGroup={handleItemSelect} />;
            default:
                return null;
        }
    };

    return (
        <div className="flex bg-white dark:bg-darkBlue">
            <Sidebar
                isSidebarVisible={isSidebarVisible}
                toggleSidebar={toggleSidebar}
                setSelectedOption={setSelectedOption}
                entityType={selectedOption}
            />
            <div className={`w-80 h-screen dark:bg-navyBlue bg-gray-100 p-2 ${isSidebarVisible ? 'hidden' : 'block'} md:block`}>
                <div className="h-full">
                    <div className="flex flex-row items-center text-white/50">
                        {!isSidebarVisible && (
                            <Bars3Icon className="h-6 w-6 cursor-pointer" onClick={toggleSidebar} />
                        )}
                        <ChatSearch />
                    </div>
                    {renderSelectedComponent()}
                </div>
            </div>
            <div className="flex-grow h-screen">
                <Dialog open={isDialogOpen} onClose={() => setIsDialogOpen(false)}>
                    <Dialog.Panel>
                        {selectedItem && (
                            <div>
                                {/* Render selected item details */}
                                <h2>{(selectedItem as any).name}</h2>
                                {/* Add more details as needed */}
                            </div>
                        )}
                    </Dialog.Panel>
                </Dialog>
            </div>
        </div>
    );
};

export default Main;    