import './App.css';

import {useCallback, useEffect, useState} from 'react';
import Header from './Components/Header';
import Content from './Components/Content';


const url = 'https://pokeapi.co/api/v2/pokemon/?limit=150';

function App() {

  const[defaultList, setDefaultList] = useState();  
  const[PokemonList, setPokemonList] = useState();



  useEffect( () => {
    const fetchPokemons = async () =>{
      const response = await fetch(url);
      const cards = await response.json();
      setDefaultList(cards);

      setPokemonList(cards.results);

    };

    fetchPokemons();
  }, []);

  
  if (!defaultList) {
    return <div>...</div>; 
  }


  return (
    <div className="App">

      <Header setter={setPokemonList} list={defaultList}/>

      {/* {PokemonList.map( (poke => <p>{poke.name}</p>))} */}
      <Content list={PokemonList}/>

    </div>
  )

  


  }

export default App;

