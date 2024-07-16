import React, { useState } from "react";
import { LoadScript, Autocomplete } from '@react-google-maps/api';

export const EventoForm = () => {
    const [autocomplete, setAutocomplete] = useState(null);
    const [selectedPlace, setSelectedPlace] = useState(null);
    const [isHidden, setIsHidden] = useState(false);
    const [evento, setEvento] = useState({
        id: 1,
        title: '',
        image: '',
        description: '',
        address: '',
        datetime: '',
        position: {
          lat: 0,
          lng: 0,
        },
    });

    const onLoad = (autocomplete) => {
        setAutocomplete(autocomplete);
    };

    const onPlaceChanged = () => {
        if (autocomplete !== null) {
          const place = autocomplete.getPlace();
          setSelectedPlace(place);
          setEvento({...evento, adress: place.formatted_address || ""});
          console.log('Selected place:', place);
        } else {
          console.log('Autocomplete is not loaded yet!');
        }
      };
    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
          const response = await fetch('https://api.example.com/eventos', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            },
            body: JSON.stringify(evento),
          });
    
          if (!response.ok) {
            throw new Error('Erro ao enviar os dados');
          }
    
          const data = await response.json();
          console.log('Dados enviados com sucesso:', data);
    
        } catch (error) {
          console.error('Erro ao enviar a requisição:', error);
        }
    };
      
    const handleFileChange = (e) => {
        const file = e.target.files[0];
    
        if (file && file.size > 5 * 1024 * 1024) { // 5MB
          if(!isHidden)
            toggleVisibility();
            return;
        }
        else{
            if(isHidden)
                toggleVisibility();
        }
    
        const reader = new FileReader();
        reader.onloadend = () => {
          setEvento({
            ...evento,
            image: reader.result,
          });
        };
        reader.readAsDataURL(file);
      };

      const toggleVisibility = () => {
        setIsHidden(!isHidden);
      };

    return(
      <LoadScript
        googleMapsApiKey={process.env.REACT_APP_GOOGLE_MAPS_API_KEY}
        libraries={["places"]}
      >
        <form onSubmit={handleSubmit} className="max-w-md mx-auto mt-7 p-4 bg-transparent rounded">
            <p className="font-semibold">Evento</p>
            <hr className="my-4 border-primary" />
            <div className="mb-4">
                <label htmlFor="nome" className="block text-primary font-semibold mb-1">
                    Nome:
                </label>
                <input
                    type="text"
                    id="nome"
                    value={evento.title}
                    onChange={(e) => setEvento({ ...evento, title: e.target.value })}
                    className="w-full px-3 py-2 border rounded text-black focus:outline-none focus:ring focus:border-blue-300"
                />
            </div>
            <div>
              <label htmlFor="Imagem" className="block text-primary font-semibold mb-1">
                Imagem:
                <input type="file" accept="image/*" onChange={handleFileChange} className="w-full px-3 py-2 border rounded text-black focus:outline-none focus:ring focus:border-blue-300"/>
                <div className={isHidden ? 'hidden' : 'block danger'}></div>
              </label>
            </div>
            <div className="mb-4">
                <label htmlFor="nome" className="block text-primary font-semibold mb-1">
                    Localidade:
                </label>
                <Autocomplete onLoad={onLoad} onPlaceChanged={onPlaceChanged}>
                    <input
                    id="location"
                    type="text"
                    placeholder="Entre com um local"
                    value={evento.address}
                    onChange={(e) => setEvento({...evento, address: e.target.value})}
                    className="location-input w-full px-3 py-2 border rounded text-black focus:outline-none focus:ring focus:border-blue-300"
                    />
                </Autocomplete>
            </div>
            <div className="mb-4">
                <label htmlFor="data" className="block text-primary font-semibold mb-1">
                    Data (dia e hora):
                </label>
                <input
                    type="datetime-local"
                    id="data"
                    value={evento.datetime}
                    onChange={(e) => setEvento({ ...evento, datetime: e.target.value })}
                    className="w-full px-3 py-2 border rounded text-black focus:outline-none focus:ring focus:border-primary"
                />
            </div>
            <button
                type="submit"
                className="bg-primary text-white w-full py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-300"
            >
                Enviar
            </button>
        </form>
      </LoadScript>
    )
}

export default EventoForm;