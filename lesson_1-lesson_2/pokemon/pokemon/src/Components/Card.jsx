import React from "react";
import { useState, useEffect } from "react";
import {Link } from 'react-router-dom';
import './Card.css'

const Card = function(props){
    const [url, setUrl] = useState(props.card.url);
    const[pokemon, setPokemon] = useState();

    var colorsMap = new Map([ //обьединить со словарем в индвиидуальной карточке покемона
            ['normal', 'gray'],
            ['fire', 'orange'],
            ['water', 'blue'],
            ['electric', 'Gold'],
            ['grass', 'green'],
            ['ice', 'light-blue'],
            ['fighting', 'brown'],
            ['poison', 'BlueViolet'],
            ['ground', 'ForestGreen'],
            ['flying' , 'SteelBlue'],
            ['psychic', 'Indigo'],
            ['bug', 'LawnGreen'],
            ['rock', 'SaddleBrown'],
            ['ghost', 'LightCyan'],
            ['dark', 'LightSlateGray'],
            ['dragon', 'Chocolate'],
            ['steel', 'Gainsboro'],
            ['fairy','MediumVioletRed']
    ]);

    useEffect( () => {
        console.log('inside CARD component inside useEffect');
        const fetchPokemon = async() => {
        const response = await fetch(url);
        const pokemon = await response.json();
        setPokemon(pokemon);

        };

        fetchPokemon();
    }, []);


    if (!pokemon){
        return <div>LOADING..........</div>
    }

    // console.log(pokemon.types);


    return(
        <div className="card">
                <Link to={`/pokemon/${pokemon.name}`}>
          <div className="pokemon_info">
            <p>{pokemon.name}</p>
            <p>#{pokemon.id}</p>
          </div>
          <img className="pokemon_image" src={pokemon.sprites.other.home.front_default}></img>
          <div className="type_container">
          {pokemon.types.map( (types) => {
              return <div className="type_box" style={{background: colorsMap.get(types.type.name)}}>
                  <span style={{  color: 'white' }}> {types.type.name}</span>
                  </div>
          })}
          </div>
          </Link>
        </div>
    )
}


export default Card;