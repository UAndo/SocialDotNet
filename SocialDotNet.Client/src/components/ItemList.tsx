import React from 'react';

interface Item {
    id: number;
    title: string;
    date: string;
}

interface ItemListProps {
    data: Item[];
    setSelectedItem: (item: Item) => void;
}

const ItemList: React.FC<ItemListProps> = ({ data, setSelectedItem }) => {
    return (
        <ul>
            {data.map((item) => (
                <li
                    key={item.id}
                    className="relative rounded-md dark:bg-black/5 bg-white p-3 mb-3 text-sm transition hover:bg-black/10"
                    onClick={() => setSelectedItem(item)}
                    role="button"
                    tabIndex={0}
                    onKeyDown={(e) => {
                        if (e.key === 'Enter' || e.key === ' ') {
                            setSelectedItem(item);
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
    );
};

export default ItemList;
