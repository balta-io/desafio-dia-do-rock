import { useState } from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';

const Navbar = () => {
    const [isExpanded, setIsExpanded] = useState(false);

    const toggleExpansion = () => {
        setIsExpanded(!isExpanded);
    };

    const expandedMenu = () => {
        if (!isExpanded) {
            setIsExpanded(true);
        }
    };



    return (
        <Router>
            <div className="flex">
                <nav className="flex flex-col bg-white w-16 h-screen tex-sm px-4">
                    <div>
                        <a href="/" className="flex items-center py-9 text-primary" >
                            <img src="https://i.ytimg.com/vi/fjMEN-csN10/maxresdefault.jpg" alt="Logo" className="w-8 h-8 rounded-full" />
                        </a>
                    </div>
                    <div className="mt-8">
                        <Link onClick={expandedMenu} to="/route1" className="flex items-center py-2 text-primary">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                                <path strokeLinecap="round" strokeLinejoin="round" d="m21 21-5.197-5.197m0 0A7.5 7.5 0 1 0 5.196 5.196a7.5 7.5 0 0 0 10.607 10.607Z" />
                            </svg>
                        </Link>
                        <Link to="/route2" className="flex items-center mt-5 py-2 text-primary">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                                <path strokeLinecap="round" strokeLinejoin="round" d="M9 6.75V15m6-6v8.25m.503 3.498 4.875-2.437c.381-.19.622-.58.622-1.006V4.82c0-.836-.88-1.38-1.628-1.006l-3.869 1.934c-.317.159-.69.159-1.006 0L9.503 3.252a1.125 1.125 0 0 0-1.006 0L3.622 5.689C3.24 5.88 3 6.27 3 6.695V19.18c0 .836.88 1.38 1.628 1.006l3.869-1.934c.317-.159.69-.159 1.006 0l4.994 2.497c.317.158.69.158 1.006 0Z" />
                            </svg>
                        </Link>
                        <button onClick={toggleExpansion} className="absolute bottom-0 mb-2 self-end mr-2 mt-2">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" className="h-6 w-6 text-gray-500">
                                {isExpanded ? (
                                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M6 18L18 6M6 6l12 12" />
                                ) : (
                                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M4 6h16M4 12h16M4 18h16" />
                                )}
                            </svg>
                        </button>
                        <Link onClick={expandedMenu} to="/route3" className="flex items-center mt-5 py-2 text-primary">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                                <path strokeLinecap="round" strokeLinejoin="round" d="M12 4.5v15m7.5-7.5h-15" />
                            </svg>
                        </Link>
                    </div>
                </nav>
                <div className={`overflow-auto transition-all duration-500 ease-in-out ${isExpanded ? 'w-96' : 'w-0'}`}>
                    {isExpanded && (
                        <div className='w-96 h-screen bg-white overflow-auto'>
                            <Routes>
                                <Route path="/route1" element={
                                    <div className='p-4 bg-gray-100 items-center py-10 text-primary '>Seu conteúdo para a rota 1 aqui!</div>
                                } />
                                <Route path="/route2" element={
                                    <div className='p-4 bg-gray-100 items-center py-10 text-primary '>Seu conteúdo para a rota 2 aqui!</div>
                                } />
                                <Route path="/route3" element={
                                    <div className='p-4 bg-gray-100 items-center py-10 text-primary '>Seu conteúdo para a rota 3 aqui!</div>
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

