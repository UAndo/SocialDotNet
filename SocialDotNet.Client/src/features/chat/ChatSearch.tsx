import React from 'react';

const ChatSearch = () => {
    return (
        <div className="search-chat flex w-full p-3">
            <input className="input text-slate-500 dark:text-gray-200 text-sm p-2 focus:outline-none bg-gray-200 dark:bg-darkBlue w-full rounded-l-md" type="text" placeholder="Search Messages" />
            <div className="bg-gray-200 dark:bg-darkBlue flex justify-center items-center pr-3 text-gray-400 rounded-r-md">
                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                    <path strokeLinecap="round" strokeLinejoin="round" d="m21 21-5.197-5.197m0 0A7.5 7.5 0 1 0 5.196 5.196a7.5 7.5 0 0 0 10.607 10.607Z" />
                </svg>
            </div>
        </div>
    );
};

export default ChatSearch;
