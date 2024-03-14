import React from 'react';
import typeToColor from "../utils/typesToColors";

const PokemonTypes = ({types}) => {
    console.log(types);
    return (
        <div className="type_container">
            {types.map(type => <div className="type_box" style={{backgroundColor: typeToColor(type.type.name)}} key={type.type.name}> {type?.type.name[0].toUpperCase() + type.type?.name.slice(1)}</div>)}
        </div>
    );
};

export default PokemonTypes;


