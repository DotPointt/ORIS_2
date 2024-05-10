const BreedingInfo = (props) => {
    if (!props) {
        return <div></div>
    }

    let weight = props.weight
    let height = props.height
    const meters = (height / 10).toFixed(1);
    const feet = Math.floor(meters / 0.3048);
    const inches = Number((meters / 0.3048 - feet).toFixed(1).toString().split('.')[1]);
    const inchesStr = (inches < 10) ? `0${inches}` : `${inches}`;
    let feetAndInches = '';
    if (inches === 0) {
        feetAndInches = `${feet}'`
    } else if (feet === 0) {
        feetAndInches = `${inchesStr}''`
    } else {
        feetAndInches = `${feet}' ${inchesStr}''`
    }
    const kg = weight / 10;
    const lbs = (kg * 2.20462).toFixed(1);

    return (<div className="info-card">
            <div className="info-card-wrapper">
                <div className="info-card-header">
                    <h2>Breeding</h2>
                </div>
                <div className="height-weight-div">
                    <div className="stats">
                        <h4>Height</h4>
                        <div className="height-weight-stats">
                            <span>{feetAndInches}</span>
                            <span>{meters} m</span>
                        </div>
                    </div>
                    <div className="stats">
                        <h4>Weight</h4>
                        <div className="height-weight-stats">
                            <span>{lbs} lbs</span>
                            <span>{kg} kg</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
};

export default BreedingInfo