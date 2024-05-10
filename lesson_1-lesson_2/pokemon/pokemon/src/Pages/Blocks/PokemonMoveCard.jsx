import {useEffect, useState} from "react";
import typeToColor from "../../utils/typesToColors";
import typeImages from "../../utils/typeImages";

export const PokemonMoveCard = ({name, url}) => {
    
    const [type, setType] = useState('')

    const nameSplit = name.split('-');
    let newName = nameSplit.map(word => word.charAt(0).toUpperCase() + word.slice(1)).join(' ');

    useEffect(() => {
        fetch(url)
            .then(response => response.json())
            .then(json => setType(json.type.name))
    }, []);
    
    return (
        <div
            style={{backgroundColor: typeToColor(type)}}
            className="pokemon-move-card">
            <div className="stats">
            <img src={typeImages[type]} alt={type}/>
            <span>{newName}</span>
            </div>
        </div>
    )
}