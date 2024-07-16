import React, { useState, useEffect, useContext } from 'react';
import CardEvent from '../CardEvent';
import dbjson from '../../db.json';
import { DarkModeContext } from '../DarkModeProvider/index';

const SearchTeste = () => {
    const [events, setEvents] = useState([]);
    const [searchTerm, setSearchTerm] = useState('');
    const { darkMode, setDarkMode } = useContext(DarkModeContext);

    useEffect(() => {
        setEvents(dbjson);
    }, []);

    const handleSearch = (event) => {
        setSearchTerm(event.target.value);
        if (event.target.value === '') {
            setEvents([]);
        } else {
            const filteredEvents = dbjson.filter(event =>
                event.bands.some(band => band.toLowerCase().includes(searchTerm.toLowerCase()))
            );
            setEvents(filteredEvents);
        }
    };

    return (
        <div>
            <div className='flex justify-center items-center'>
                <input
                    type='text'
                    className='border border-primary rounded p-2 mr-3 '
                    value={searchTerm}
                    onChange={handleSearch}
                />
            </div>
            {searchTerm && (
                events.length > 0 ? (
                    events.map(event => (
                        <div className='mb-5 mt-5' key={event.id}>
                            <CardEvent
                                key={event.id}
                                title={event.title}
                                address={event.address}
                                datetime={event.datetime}
                                image={event.image}
                            />
                        </div>
                    ))
                ) : (
                    <p>Não foi possível encontrar a banda: {searchTerm}</p>
                )
            )}
        </div>
    );
};

export default SearchTeste;
