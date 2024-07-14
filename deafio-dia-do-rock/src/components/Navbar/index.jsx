import { useState } from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';

const Navbar = () => {
    const [isExpanded, setIsExpanded] = useState(false);

    const toggleExpansion = () => {
        setIsExpanded(!isExpanded);
    };

    return (
        <Router>
            <div className="flex">
                <nav className={`flex flex-col bg-white ${isExpanded ? 'w-96' : 'w-16'} h-screen tex-sm px-4 transition-all duration-200`}>
                    <div className="mt-8">
                        <div>
                            <a href="/" className="flex items-center py-9 text-primary" >
                                <img src="https://i.ytimg.com/vi/fjMEN-csN10/maxresdefault.jpg" alt="Logo" className="w-8 h-8 rounded-full" />
                            </a>
                        </div>

                        <Link to="/route1" className="flex items-center py-2 text-primary" onClick={toggleExpansion}>
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                                <path strokeLinecap="round" strokeLinejoin="round" d="m21 21-5.197-5.197m0 0A7.5 7.5 0 1 0 5.196 5.196a7.5 7.5 0 0 0 10.607 10.607Z" />
                            </svg>
                        </Link>
                        <Link to="/route2" className="flex items-center mt-5 py-2 text-primary">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                                <path strokeLinecap="round" strokeLinejoin="round" d="M9 6.75V15m6-6v8.25m.503 3.498 4.875-2.437c.381-.19.622-.58.622-1.006V4.82c0-.836-.88-1.38-1.628-1.006l-3.869 1.934c-.317.159-.69.159-1.006 0L9.503 3.252a1.125 1.125 0 0 0-1.006 0L3.622 5.689C3.24 5.88 3 6.27 3 6.695V19.18c0 .836.88 1.38 1.628 1.006l3.869-1.934c.317-.159.69-.159 1.006 0l4.994 2.497c.317.158.69.158 1.006 0Z" />
                            </svg>
                        </Link>
                        <Link to="/route3" className="flex items-center mt-5 py-2 text-primary">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
                                <path strokeLinecap="round" strokeLinejoin="round" d="M12 4.5v15m7.5-7.5h-15" />
                            </svg>
                        </Link>
                    </div>
                </nav>
                {isExpanded && (
                    <div className='w-full'>
                        <Routes>
                            <Route path="/route1" element={<div className='p-4 bg-gray-100 items-center py-10 text-primary ' >Seu conteúdo para a rota 1 aqui!</div>} />
                            <Route path="/route2" element={<div className='p-4 bg-gray-100 items-center py-10 text-primary '>Seu conteúdo para a rota 2 aqui!</div>} />
                            <Route path="/route3" element={<div className='p-4 bg-gray-100 items-center py-10 text-primary '>Seu conteúdo para a rota 3 aqui!</div>} />
                        </Routes>
                    </div>
                )}
            </div>
        </Router>
    );
};

export default Navbar;

