import React, { useState } from 'react';
import RegisterForm from '../features/auth/RegisterForm';

const Register = () =>
{

    return (
        <div className="flex justify-center items-center h-screen bg-custom-gradient">
            <RegisterForm />
        </div>
    );
};

export default Register;
