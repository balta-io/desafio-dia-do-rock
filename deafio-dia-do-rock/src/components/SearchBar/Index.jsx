import { IoMdSearch } from "react-icons/io";

function SearchBar() {
    return (
        <div>

            <h2 className="input-title">Buscar evento</h2>

            <div className="search-bar">
                <IoMdSearch className="lupa" />
                <input type="text" placeholder="Nome da banda..."></input>
            </div>
        </div>
    )
}

export default SearchBar