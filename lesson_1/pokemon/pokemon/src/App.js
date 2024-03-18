import './App.css';

import {useCallback, useEffect, useState} from 'react';
import Header from './Components/Header';
import Content from './Components/Content';
import { useFetcher } from 'react-router-dom';
import axios from 'axios'


const url = 'https://pokeapi.co/api/v2/pokemon/?limit=40';

function App() {

  const[defaultList, setDefaultList] = useState();  
  const[PokemonList, setPokemonList] = useState([]);
  const[PokemonSearchedList, setPokemonSearchedList] = useState();
  const[fetching, setFetching] = useState(true);
  const[pages, setPages] = useState(0);



  // useEffect( () => {
  //   const fetchPokemons = async () =>{
  //     const response = await fetch(url);
  //     const cards = await response.json();
  //     setDefaultList(cards);

  //     setPokemonList(cards.results);

  //   };

  //   fetchPokemons();
  // }, []);

  useEffect( () => {
    if (fetching){
      axios.get(`https://pokeapi.co/api/v2/pokemon/?limit=30&offset=${pages}`)
          .then(response => {
            setPages( prevState => prevState + 20);
            setDefaultList(response.data);
            setPokemonList([...PokemonList, ...response.data.results]);

            // setPokemonList(response.data.results);

          })
          .finally( () => setFetching(false) );
    }
  }, [fetching])


  useEffect( () => {
    document.addEventListener('scroll', scrollHandler)

    return function () {
      document.removeEventListener('scroll', scrollHandler)
    };
  }, [] )

  const scrollHandler = (e) => {
    if (e.target.documentElement.scrollHeight - (e.target.documentElement.scrollTop + window.innerHeight) < 100){
        setFetching(true);
        console.log('fetcing set true');
    }
  }

  if (!defaultList) {
    return <div>...</div>; 
  }


  console.log("PokemonSearchedList");
  console.log(PokemonSearchedList);

  if (PokemonSearchedList){
      return (
        <div className="App">
        <Header setter={setPokemonSearchedList} list = {defaultList}></Header>
          <Content list={PokemonSearchedList}/>
      </div>
      );
  }


  return (
    <div className="App">
      <Header setter={setPokemonSearchedList} list = {defaultList}></Header>
      <Content list={PokemonList}/>
    </div>
  ) 





  }

export default App;

