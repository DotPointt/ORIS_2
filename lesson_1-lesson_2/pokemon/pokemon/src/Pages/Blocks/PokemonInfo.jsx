import PokemonTypes from "../../Components/PokemonTypes";

const PokemonInfo = ({pokemon}) => {
    if (!pokemon) {
        return <div></div>
    }


    return (
        <div className="info-card">
            <div className="info-card-wrapper">
                <div className="info-card-header">
                    <div className="pokemon-general-info">
                        <h3>#{pokemon?.id.toString().padStart(3, '0')}</h3>
                        <h2>{pokemon.name[0].toUpperCase() + pokemon.name.slice(1)}</h2>
                    </div>
                    <div className="type_box">
                        <PokemonTypes types={pokemon.types}/>
                    </div>
                </div>
                <div className="info-card-content">
                    <div className="info-card-stats">
                        <div className="stat-item">
                            <h4>HP</h4>
                            <div className="stat-bar hp">
                                <div className="stat-fill" style={{ width: `${(pokemon.stats[0].base_stat / 150) * 100}%` }}></div>
                            </div>
                        </div>
                        <div className="stat-item">
                            <h4>Attack</h4>
                            <div className="stat-bar attack">
                                <div className="stat-fill" style={{ width: `${(pokemon.stats[1].base_stat / 150) * 100}%` }}></div>
                            </div>
                        </div>
                        <div className="stat-item">
                            <h4>Defense</h4>
                            <div className="stat-bar defense">
                                <div className="stat-fill" style={{ width: `${(pokemon.stats[2].base_stat / 150) * 100}%` }}></div>
                            </div>
                        </div>
                        <div className="stat-item">
                            <h4>Speed</h4>
                            <div className="stat-bar speed">
                                <div className="stat-fill" style={{ width: `${(pokemon.stats[5].base_stat / 150) * 100}%` }}></div>
                            </div>
                        </div>
                    </div>
                    <img className="pokemon-general-info-image" src={pokemon.sprites.other.home.front_default} alt="Pokemon"/>
                </div>
            </div>
        </div>
    )
};

export default PokemonInfo