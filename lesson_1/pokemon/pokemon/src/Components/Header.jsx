import './Header.css'
import React from "react";
import { useState, useEffect } from "react";


const Header = function(props){

  const defaultPokemonList = props.list.results
  const [searchItem, setSearchItem] = useState('');


  useEffect(() => {
    const Debounce = setTimeout(() => {
      // console.log(defaultPokemonList);
      const filteredPokemons = filterPokemons(searchItem, defaultPokemonList);
      props.setter(filteredPokemons);
    }, 300);

    return () => clearTimeout(Debounce);
  }, [searchItem])


  // useEffect(() => {
  //     if (searchItem.length !== 0) {
  //         const filiteredPokemons = pokemonsList.filter((item) => {
  //             return (item.pokemon.name)
  //         });
  //         console.log("po")
  //         console.log(pokemonsList);
  //         props.setter(filiteredPokemons);
  //     }
  //     else{
  //         props.setter(pokemonsList);
  //     }
  // }, [searchItem])

  // useEffect(() =>{
  //     props.setter(searchResult);
  // }, [searchResult])



    return(
        <header>
          <img className='pokeball' src='image.png'/>  
        <div className='searchContainer'>
          <p>Who are you looking for?</p>
          <div className='searchLine'>
            <img className='magnifier' src='search.png'/> 
            <input className='searchBar' placeholder='        E.g Pikachu' onChange={(e) => setSearchItem(e.target.value)}></input> 
            <button className='btn'>GO</button>
          </div>
        </div>
    </header>
    )
}

const filterPokemons = (searchText, defaultList) =>{
  if(!searchText){
    return defaultList;
  }

  return defaultList.filter(pokemon =>
  pokemon.name.toLowerCase().includes(searchText.toLowerCase())
  );

}

export default Header;


// return defaultList.filter(({pokemon}) =>
// pokemon.name.toLowerCase().includes(searchText.toLowerCase())
// );