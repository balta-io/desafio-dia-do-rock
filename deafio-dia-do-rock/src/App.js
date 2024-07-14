import { useContext } from 'react';
import { DarkModeContext } from './components/DarkModeProvider';
import './App.css';
import Navbar from './components/Navbar';
import Map from "./components/map";
import dbjson from './db.json';

function App() {
  const { darkMode } = useContext(DarkModeContext);

  return (
    <div className={`flex ${darkMode ? 'dark' : ''}`}>
      <Navbar />
      <div className='flex flex-col w-full'>
        <Map zoom={4} markers={dbjson} center={{ lat: -22.977112, lng: -43.396305 }} />
      </div >

    </div >
  );
}

export default App;
