thankyou for readint this README.TXT
this code is rather simple to run. there are a few menues to pass through and it is not yet fully complete. the menu options that work are play game and build a new deck.
what you select build deck in the main menu it will lead you to a secondary menu. the option of modifying an existing deck has not yet been implemented and so i recomend that you do not select it.
the ther options all work at the moment.
this project was extensive it was fun to work with the api and to discover how to get the deck builder to work properly. it broke down into a few major parts
first geting the menues and simple coadeing done so that it would work with the play game function.
second getting the api to work. the .jsno serialiser was being difficult and so i had to make a class that mimics a deserialiser. it serched the .json text for the parts of the cards that are needed and 
extracts them. it was a difficult thing to code and i think that if i were to do this project differently i would start with getting the deserialiser working. but i am proud that i was able to do 
this project in this way.
the third was the files. working with files is difficult because where the computer lookes for them is something i have not yet grasped. however i was able to get files implimented in the end. 

the next major part of the project was the actual game first the classes.
the Card class handles a lot of the information tradeing between deck/game and the 4 card objects. Card is an abstract parent class that the 4 card classes inharit from
those classes are:

Land that handles the mana of the player

creature that is the main gampley of the game. it is not fully implemented as the abilities are infinate in what they can do.

enchantment. this card type is barly implemented in that these cards can be part of the deck but they do nothing to the game yet.

spells these cards type is barly implemented in that these cards can be part of the deck but they do nothing to the game yet.

the game class handles one players perspective of the game. it works with others of its class to accomplish the game and moved card objects inbetween its decks to play the game.

the deck class is a simple list of cards that handles all cards. 

keyword is an enumerated data type that lists abbilityes that have not been implemented yet
Rarity is an enumerated data type that has been fully implimented. 
color is the next enumerated data type that needs to be implimented

placeholdercard is a class that handles deserialiseing the .json text from the Api request. and converts them into the card types. ie Land Creature Enchantment Spell