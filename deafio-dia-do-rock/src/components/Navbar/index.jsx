import { useState, useContext } from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import { DarkModeContext } from '../DarkModeProvider/index';
import SearchBar from '../SearchBar/Index';
import EventoForm from '../EventoForm/index';


const Navbar = () => {
    const [isExpanded, setIsExpanded] = useState(false);
    const { darkMode, setDarkMode } = useContext(DarkModeContext);

    const toggleExpansion = () => {
        setIsExpanded(!isExpanded);
    };

    const expandedMenu = () => {
        if (!isExpanded) {
            setIsExpanded(true);
        }
    };

    const toggleMode = () => {
        setDarkMode(!darkMode);
    };

    return (
        <Router>
            <div className="flex">
                <nav className={`navbar ${darkMode ? 'bg-dark text-light' : 'bg-light text-dark'} flex flex-col  w-16 h-screen tex-sm px-4`}>
                    <div>
                        <a href="/" className="flex items-center py-9 text-primary" >
                            <img src="https://i.ytimg.com/vi/fjMEN-csN10/maxresdefault.jpg" alt="Logo" className="w-8 h-8 rounded-full" />
                        </a>
                    </div>
                    <div className="mt-8">
                        <Link onClick={expandedMenu} to="/search" className="flex items-center py-2 text-primary">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                                <path strokeLinecap="round" strokeLinejoin="round" d="m21 21-5.197-5.197m0 0A7.5 7.5 0 1 0 5.196 5.196a7.5 7.5 0 0 0 10.607 10.607Z" />
                            </svg>
                        </Link>
                        <Link to="/map" className="flex items-center mt-5 py-2 text-primary">
                            <svg onClick={toggleExpansion} xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                                <path strokeLinecap="round" strokeLinejoin="round" d="M9 6.75V15m6-6v8.25m.503 3.498 4.875-2.437c.381-.19.622-.58.622-1.006V4.82c0-.836-.88-1.38-1.628-1.006l-3.869 1.934c-.317.159-.69.159-1.006 0L9.503 3.252a1.125 1.125 0 0 0-1.006 0L3.622 5.689C3.24 5.88 3 6.27 3 6.695V19.18c0 .836.88 1.38 1.628 1.006l3.869-1.934c.317-.159.69-.159 1.006 0l4.994 2.497c.317.158.69.158 1.006 0Z" />
                            </svg>
                        </Link>
                        <div className={`${darkMode ? 'bg-dark' : 'bg-light'} absolute bottom-0 mb-2 self-end mr-2 mt-2`}>
                            <button onClick={toggleMode} className={`${darkMode ? 'text-yellow-600' : 'text-dark'} top-0 right-0 z-10`}>
                                {darkMode ?
                                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="size-6">
                                        <path d="M12 2.25a.75.75 0 0 1 .75.75v2.25a.75.75 0 0 1-1.5 0V3a.75.75 0 0 1 .75-.75ZM7.5 12a4.5 4.5 0 1 1 9 0 4.5 4.5 0 0 1-9 0ZM18.894 6.166a.75.75 0 0 0-1.06-1.06l-1.591 1.59a.75.75 0 1 0 1.06 1.061l1.591-1.59ZM21.75 12a.75.75 0 0 1-.75.75h-2.25a.75.75 0 0 1 0-1.5H21a.75.75 0 0 1 .75.75ZM17.834 18.894a.75.75 0 0 0 1.06-1.06l-1.59-1.591a.75.75 0 1 0-1.061 1.06l1.59 1.591ZM12 18a.75.75 0 0 1 .75.75V21a.75.75 0 0 1-1.5 0v-2.25A.75.75 0 0 1 12 18ZM7.758 17.303a.75.75 0 0 0-1.061-1.06l-1.591 1.59a.75.75 0 0 0 1.06 1.061l1.591-1.59ZM6 12a.75.75 0 0 1-.75.75H3a.75.75 0 0 1 0-1.5h2.25A.75.75 0 0 1 6 12ZM6.697 7.757a.75.75 0 0 0 1.06-1.06l-1.59-1.591a.75.75 0 0 0-1.061 1.06l1.59 1.591Z" />
                                    </svg>
                                    :
                                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="size-6">
                                        <path fillRule="evenodd" d="M9.528 1.718a.75.75 0 0 1 .162.819A8.97 8.97 0 0 0 9 6a9 9 0 0 0 9 9 8.97 8.97 0 0 0 3.463-.69.75.75 0 0 1 .981.98 10.503 10.503 0 0 1-9.694 6.46c-5.799 0-10.5-4.7-10.5-10.5 0-4.368 2.667-8.112 6.46-9.694a.75.75 0 0 1 .818.162Z" clipRule="evenodd" />
                                    </svg>
                                }
                            </button>
                        </div>
                        <Link onClick={expandedMenu} to="/novo-evento" className="flex items-center mt-5 py-2 text-primary">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                                <path strokeLinecap="round" strokeLinejoin="round" d="M12 4.5v15m7.5-7.5h-15" />
                            </svg>
                        </Link>
                    </div>
                </nav>
                <div className={`overflow-auto transition-all duration-500 ease-in-out ${isExpanded ? 'w-96' : 'w-0'}`}>
                    {isExpanded && (
                        <div className={`navbar ${darkMode ? 'bg-dark-100 text-light' : 'bg-light text-dark'} w-96 h-screen overflow-auto`}>
                            <Routes>
                                <Route path="/search" element={
                                    <div className='p-4  items-center py-10 text-primary '>
                                        <SearchBar /></div>
                                } />
                                <Route path="/map" element={
                                    <div className='p-4 items-center py-10 text-primary '>Seu conteúdo para a rota MAPA aqui!</div>
                                } />
                                <Route path="/novo-evento" element={
                                    <div className='p-4  items-center py-10 text-primary '>
                                        <EventoForm />
                                    </div>
                                } />
                            </Routes>
                        </div>
                    )}
                </div>
            </div>
        </Router>
    );
};

export default Navbar;

