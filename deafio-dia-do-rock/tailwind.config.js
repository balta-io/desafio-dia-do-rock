/** @type {import('tailwindcss').Config} */
module.exports = {
  darkMode: 'selector',
  content: [
    "./src/**/*.{js,jsx,ts,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        'primary': '#8625D2',
        'dark': '#131219',
        'light': '#ECEDE6',
      },
    },
  },
  plugins: [],
}

