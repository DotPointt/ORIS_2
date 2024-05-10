    var typesAndColors = new Map([ //обьединить со словарем в индвиидуальной карточке покемона
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

const typeToColor = (type) => {
    let lowerType = type.toLowerCase();

    if(typesAndColors.get(lowerType) !== undefined)
        return typesAndColors.get(lowerType);

    return "#0080FF";
}

export default typeToColor;