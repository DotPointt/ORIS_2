const AbilitiesInfo = ({abilities}) => {
    if (abilities.length === 0) {
        return <div></div>
    }
    
    const firstSplitedName = abilities[0].name.split('-');
    const firstName = firstSplitedName.map(word => word[0].toUpperCase() + word.slice(1)).join(' ');
    const secondSplitedName = abilities[1].name.split('-');
    const secondName = secondSplitedName.map(word => word[0].toUpperCase() + word.slice(1)).join(' ');
    return (
        <div className="info-card">
            <div className="info-card-wrapper">
                <div className="info-card-header">
                    <h2>Abilities</h2>
                </div>
                <div className="abilities-list">
                    <div className="ability first">
                        <div className="ability-letter">
                            <span className="ability-first-letter">{firstName[0]}</span>
                        </div>
                        <span className="ability-name">{firstName}</span>
                    </div>
                    <div className="ability second">
                        <div className="ability-letter">
                            <span className="ability-second-letter">{secondName[0]}</span>
                        </div>
                        <span className="ability-name">{secondName}</span>
                    </div>
                </div>
            </div>
        </div>
    )
};

export default AbilitiesInfo