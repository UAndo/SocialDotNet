import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Home from './pages/Home.tsx';
import Login from './pages/Login.tsx';
import Register from './pages/Register.tsx';
import { AuthProvider } from './features/auth/AuthProvider.tsx';

function App()
{
    return (
        <AuthProvider>
            <BrowserRouter>
                <Routes>
                    <Route path="/login" element={<Login />} />
                    <Route path="/register" element={<Register />} />
                    <Route path="/*" element={<Home />} />
                    <Route path="*" element={<div>Page Not Found</div>} />
                </Routes>
            </BrowserRouter>
        </AuthProvider>
    );
}

export default App;
