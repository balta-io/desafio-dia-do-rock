import {FaCheckCircle} from "react-icons/fa";
import {MdOutlineError} from "react-icons/md";

export default function StatusComponent({isSuccess = 1, title, message, onClick}) {
    return (
        <div className="flex flex-col gap-4 justify-center items-center text-center text-dark">
            {isSuccess
                ? <FaCheckCircle className="text-success text-5xl"/>
                : <MdOutlineError className="text-danger text-5xl"/>
            }
            <h2 className="font-bold text-xl">{title}</h2>
            <p>{message}</p>
            <button
                onClick={onClick}
                className="bg-primary hover:bg-primary-600 transition ease-in-out w-full p-4 text-white rounded-lg font-bold">
                Fechar
            </button>
        </div>
    );
}
