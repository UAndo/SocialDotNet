import React from 'react';
import { NavLink } from 'react-router-dom';

const Sidebar: React.FC = () => {
    return (
        <div className="sidebar">
            <ul>
                <li><NavLink to="/main/chats" className="active">Чати</NavLink></li>
                <li><NavLink to="/main/calls" className="active">Дзвінки</NavLink></li>
                <li><NavLink to="/main/friends" className="active">Друзі</NavLink></li>
                <li><NavLink to="/main/groups" className="active">Групи</NavLink></li>
            </ul>
        </div>
    );
};

export default Sidebar;
