import { DarkModeContext } from '../DarkModeProvider/index';
import { useContext } from 'react';

function CardEvent({ title, address, datetime, image }) {
    const { darkMode } = useContext(DarkModeContext);
    const addressCountry = address.split(',')[1].trim();
    const addressCity = address.split(',')[0].trim();



    const date = new Date(datetime);

    const monthNames = ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"];

    const formattedDate = date.getDate() + '/' + monthNames[date.getMonth()];

    return (
        <div className={`${darkMode ? 'bg-dark text-light' : 'bg-light text-dark'} max-w-sm rounded overflow-hidden shadow-lg border-1 p-8 flex justify-between items-center h-40`}>
            <div className="flex items-center">
                {image && (
                    <img
                        className="w-10 h-10 rounded-full mr-4"
                        src={image}
                        alt="Logo do evento"
                    />
                )}
                <div className="flex flex-col">
                    <div className="font-bold text-base  mb-2">{title}</div>
                    <p className="text-sm">
                        {addressCity}
                    </p>
                    <p className=" text-xs">
                        {addressCountry}
                    </p>
                </div>
            </div>
            <div className="text-right ml-8">
                <p className="text-gray-700 text-sm mt-2">{formattedDate}</p>
            </div>
        </div>
    );
}

export default CardEvent;
