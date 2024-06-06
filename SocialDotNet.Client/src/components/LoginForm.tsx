import { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import InputField from './InputField';

function LoginForm() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const navigate = useNavigate();

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try {
            const response = await axios.post('auth/login', { email, password });
            console.log('Login successful:', response.data);
            // Можливо, зберегти токен в localStorage або виконати інші дії
            localStorage.setItem('jwt', response.data.token);
            navigate('/');
        } catch (error) {
            console.error('Login failed:', error);
            // Обробка помилок
        }
    };

    return ( 
        <div className="bg-darkBlue p-12 rounded-lg shadow-lg w-full max-w-fit flex flex-row">
            <div className="flex flex-col w-1/2">
                <div className="flex flex-col items-center">
                    <h2 className="text-2xl font-semibold text-white">Sign in</h2>
                    <h5 className="text-white/50 mb-6">Enter your email and password to sign in</h5>
                </div>
                <form className="space-y-4" onSubmit={handleSubmit}>
                    <div className="flex flex-col">
                    <InputField
                        label="Email"
                        type="email"
                        placeholder="Enter your email..."
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                    </div>
                    <div className="flex flex-col">
                    <InputField
                        label="Password"
                        type="password"
                        placeholder="Enter your password..."
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                    </div>
                    <div className="text-left">
                        <a href="/forgot-password" className="text-lightBlue hover:underline">Forgot your password?</a>
                    </div>
                    <div>
                        <button
                            type="submit"
                            className="w-full bg-royalPurple text-white p-2 rounded focus:outline-none"
                        >
                            Sign in
                        </button>
                    </div>
                    <div className="mt-4 text-left">
                    <a href="/register" className="text-lightBlue hover:underline">Create an account</a>
                </div>
                </form>
            </div>
            <div className="mt-6 flex flex-col items-center justify-center w-1/2">
                <img src="src/assets/images/qrcode.jpg" alt="qr-code" />
                <p className="text-center text-white mt-4">
                Sign in using QR code
                <br />
                <span className="text-gray-400">Go to Settings, then — Connected devices.</span>
            </p>
            </div>
        </div>
    );
}

export default LoginForm;
