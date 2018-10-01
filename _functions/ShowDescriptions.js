function ShowDescription(name){
    var text = "";

    switch(name){
        case "dwarf":
            text = "The Dwarven stronghold of Torggskin is situated beneath the Pierced Mountains, between the Fogridden and Lyfbreath Rivers. For as long as any living soul can recall, the Dwarven clan of IronForge has ruled the Kingdom peacefully. The neighboring Elves and Halflings generally keep their distance, though the Dwarves do maintaini a pathway through the mountains for those who desire to cross it. Dwarves are generally known as Fighters and seem to have a harder time mastering other specialties, though it is not unheard of.";
            currentSelection = "dwarf";
            break;
        case "elf":
            text = "Nestled deep within the Lorngrave Forest, the Elves do not have a large city like other Races. Instead, they make their homes wherever the Forest permits. A reserved people, Elves usually do not travel beyonf the River Lyfbreath - a natural border to their Forest. Elves are adept Rangers and make for decent Rogues because of their ability to blend into the Forest.";
            currentSelection = "elf";
            break;
        case "halfling":
            text = "Split between the Ice Tundra and the Frostbitten Forest the Halflings enjoy a life helping anyone who crosses their path. Although a great concentration of Halflings is found in the Tundra and Forest, they can be found in almost every corner of Anagorth. Halflings make exceptional Rogues and decent Wizards.";
            currentSelection = "halfling";
            break;
        case "human":
            text = "Humans only relatively recently settled in the region of Anagorth, but the managed to usurp poer in the largest area and claim it for themselves. Humans seem to be proficient in each specialty equally.";
            currentSelection = "human";
            break;
    }

    $("#description").text(text);
}