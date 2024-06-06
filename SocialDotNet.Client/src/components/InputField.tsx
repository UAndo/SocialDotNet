import React from 'react';

interface InputFieldProps {
    label: string;
    type: string;
    placeholder: string;
    value: string;
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
}

const InputField: React.FC<InputFieldProps> = ({ label, type, placeholder, value, onChange }) => {
    return (
        <div className="flex flex-col">
            <span className="text-white mb-1">{label}</span>
            <input
                type={type}
                placeholder={placeholder}
                className="w-full p-2 rounded bg-navyBlue text-white/50 focus:outline-none"
                value={value}
                onChange={onChange}
            />
        </div>
    );
};

export default InputField;
