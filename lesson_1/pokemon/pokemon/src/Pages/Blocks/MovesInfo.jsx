import {PokemonMoveCard} from "./PokemonMoveCard";

const MovesInfo = ({moves}) => {
    if (!moves) {
        return <div></div>
    }

    moves = moves.slice(0, 6)

    return (
        <div className="info-card">
            <div className="info-card-wrapper">
                <div className="info-card-header">
                    <h2>Moves</h2>
                </div>
                <div className="moves-container">
                    <div className="moves-list">
                        {moves.slice(0, 3).map((move) => <PokemonMoveCard name={move.name} url={move.url} key={move.name} />)}
                    </div>
                    <div className="moves-list">
                        {moves.slice(3, 6).map((move) => <PokemonMoveCard name={move.name} url={move.url} key={move.name}/>)}
                    </div>
                </div>
            </div>
        </div>
    )
};

export default MovesInfo