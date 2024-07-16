import {useContext, useEffect, useState} from 'react';
import { DarkModeContext } from './components/DarkModeProvider';
import './App.css';
import Navbar from './components/Navbar';
import Map from "./components/map";
import {getAll} from "./Api/eventoApi";

function App() {
  const { darkMode } = useContext(DarkModeContext);
  const [eventos, setEventos] = useState([]);

  async function getEventos() {
      try{
          const data = await getAll();
          setEventos(data);
      } catch (error){}
  }

    useEffect(() => {
        getEventos();
    }, []);

  return (
    <div className={`flex ${darkMode ? 'dark' : ''}`}>
      <Navbar />
      <div className='flex flex-col w-full'>
        <Map zoom={4} markers={eventos} center={{ lat: -22.977112, lng: -43.396305 }} />
      </div >

    </div >
  );
}

export default App;
