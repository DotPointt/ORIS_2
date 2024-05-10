import React from "react";
import { useParams } from "react-router-dom";
import {useEffect, useState} from "react";
import PokemonHeader from './PokemonHeader'
import InfoBlocks from "./InfoBlocks";


const PokemonPage = function(){
    
    const name = useParams().pokemonName;

    const [pokemon, setPokemon] = useState('')
    const [moves, setMoves] = useState([])
    const [abilities, setAbilities] = useState([])
    
        useEffect(() =>{
            fetch(`https://pokeapi.co/api/v2/pokemon/${name}`)
                .then(response => response.json())
                .then(data => {
                    setPokemon(data)
                    setMoves(data.moves.map(i => i.move))
                    setAbilities(data.abilities.map(i => i.ability))
                })
                .catch(error => console.error('Error fetching initial data:', error));
        }, [name])
        


        return (
            
            <div>
                <PokemonHeader/>
                <InfoBlocks name={name}/>
            </div>
        )



};



export default PokemonPage;