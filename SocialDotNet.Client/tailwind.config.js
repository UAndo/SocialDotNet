/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        'navyBlue': '#1B263B',
        'darkBlue': '#0D1B2A',
        'white': '#FFFFFF',
        'royalPurple': '#6D50AE',
        'lightBlue': '#95ADCF',
      }
    },
  },
  plugins: [],
}