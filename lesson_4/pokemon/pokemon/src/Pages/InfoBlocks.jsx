import {useEffect, useState} from "react";
import './InfoBlocks.css'
import PokemonInfo from "./Blocks/PokemonInfo";
import BreedingInfo from "./Blocks/BreedingInfo";
import MovesInfo from "./Blocks/MovesInfo";
import AbilitiesInfo from "./Blocks/AbilitiesInfo";

const InfoBlocks = (props) => {
    const [pokemon, setPokemon] = useState('')
    const [moves, setMoves] = useState([])
    const [abilities, setAbilities] = useState([])

    useEffect(() =>{
        fetch(`https://pokeapi.co/api/v2/pokemon/${props.name}`)
            .then(response => response.json())
            .then(data => {
                setPokemon(data)
                setMoves(data.moves.map(i => i.move))
                setAbilities(data.abilities.map(i => i.ability))
            })
            .catch(error => console.error('Error fetching initial data:', error));
    }, [props.name])
    
    
    return (
        <div className="infoblocks-wrapper">
            <PokemonInfo pokemon={pokemon}/>
            <BreedingInfo height={pokemon.height} weight={pokemon.weight}/>
             <MovesInfo moves={moves}/>
            <AbilitiesInfo abilities={abilities}/>
        </div>
    )
}

export default InfoBlocks