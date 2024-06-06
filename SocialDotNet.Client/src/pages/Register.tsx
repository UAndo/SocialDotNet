// import React, { useState } from 'react';
// import RegisterForm from '../components/RegisterForm';

// const Register = () => {
//     const [firstName, setFirstName] = useState('');
//     const [lastName, setLastName] = useState('');
//     const [email, setEmail] = useState('');
//     const [password, setPassword] = useState('');
//     const [confirmPassword, setConfirmPassword] = useState('');
//     const [error, setError] = useState('');

//     const handleSubmit = async (e) => {
//         e.preventDefault();

//         // Validate input fields
//         if (!firstName || !lastName || !email || !password || !confirmPassword) {
//             setError('Please fill in all fields.');
//             return;
//         }

//         if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) {
//             setError('Please enter a valid email address.');
//             return;
//         }

//         if (password !== confirmPassword) {
//             setError('Passwords do not match.');
//             return;
//         }

//         // Clear error message
//         setError('');

//         const requestBody = {
//             FirstName: firstName,
//             LastName: lastName,
//             Email: email,
//             Password: password,
//         };

//         try {
//             const response = await fetch('auth/register', {
//                 method: 'POST',
//                 headers: {
//                     'Content-Type': 'application/json',
//                 },
//                 body: JSON.stringify(requestBody),
//             });

//             if (!response.ok) {
//                 throw new Error(`HTTP error! status: ${response.status}`);
//             }

//             const data = await response.json();
//             console.log('Success:', data);
//         } catch (error) {
//             console.error('Error:', error);
//         }
//     };

//     return (
//         <div className="flex justify-center items-center h-screen bg-custom-gradient">
//             <RegisterForm />
//         </div>
//     );
// };

// export default Register;
