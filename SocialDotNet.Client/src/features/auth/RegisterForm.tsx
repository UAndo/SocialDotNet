import { useState } from 'react';
import axios from 'axios';
import InputField from '../../components/InputField';

function RegisterForm() {
    const [email, setEmail] = useState('');
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try {
            const response = await axios.post('/auth/register', { email, password, firstName, lastName, username });
            console.log('Register successful:', response.data);
            // Можливо, зберегти токен в localStorage або виконати інші дії
        } catch (error) {
            console.error('Register failed:', error);
            // Обробка помилок
        }
    };

    return (
        <div className="bg-darkBlue p-12 rounded-lg shadow-lg w-full max-w-fit flex flex-row">
            <div className="flex flex-col w-80">
                <div className="flex flex-col items-center">
                    <h2 className="text-2xl font-semibold text-white mb-6">Sign in</h2>
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
                            label="First name"
                            type="text"
                            placeholder="Enter your first name..."
                            value={firstName}
                            onChange={(e) => setFirstName(e.target.value)}
                        />
                    </div>
                    <div className="flex flex-col">
                        <InputField
                            label="Last name"
                            type="text"
                            placeholder="Enter your last name..."
                            value={lastName}
                            onChange={(e) => setLastName(e.target.value)}
                        />
                    </div>
                    <div className="flex flex-col">
                        <InputField
                            label="Username"
                            type="text"
                            placeholder="Enter your username..."
                            value={username}
                            onChange={(e) => setUsername(e.target.value)}
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
                    <div>
                        <button
                            type="submit"
                            className="w-full bg-royalPurple text-white p-2 rounded focus:outline-none"
                        >
                            Sign in
                        </button>
                    </div>
                    <p className="text-center text-white/50 mt-4">
                        By clicking sign up, you agree to our 
                        <a href="#" className="text-lightBlue hover:underline"> Terms of Service</a> and 
                        <a href="#" className="text-lightBlue hover:underline"> Privacy Policy</a>
                    </p>
                    <div className="mt-4 text-left">
                        <a href="/login" className="text-lightBlue hover:underline">Already have an account?</a>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default RegisterForm;
