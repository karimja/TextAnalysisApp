Feature: Unqiue Word Count in a sentence
	In order to ensure that i am not repeating myself
	As an author
	I want to know how many times a word appears in a sentence

Scenario: Return unqiue word count for a sentence
	Given a sentence
	When text Analyzer is run
	Then return a distinct list of words in the sentence and the number of times thay have occurred

Scenario: Return empty word count
	Given a empty sentence
	When text Analyzer is run 
	Then return an empty list

Scenario: Return empty word count as senetence has no letters
	Given a sentence only contains numbers
	When text Analyzer is run 
	Then return an empty list

Scenario: Return exception on null senetence
	Given a sentence is null
	When text Analyzer is run with a null sentence
	Then an exception is thrown

Scenario: Return unqiue word count for a sentence with non-letter characters
	Given a sentence with non-letter characters
	When text Analyzer is run 
	Then return a distinct list of words in the sentence and the number of times thay have occurred