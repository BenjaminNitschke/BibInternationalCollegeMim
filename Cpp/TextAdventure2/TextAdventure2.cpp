#include "stdafx.h"
#include <iostream>

int main()
{
	std::cout << "Welcome to my great text adventure" << std::endl;
	std::cout << "You are Valdor of Tartanis, a great warrior." << std::endl;
	std::cout << "You are currently in the wood of Elenor." << std::endl;
	std::cout << "Do you want to go forward (1), or do you want to turn back (2) or do you want to go left to the cliff (3)." << std::endl;
	unsigned int number;
	std::cin >> number;
	if (number == 1)
		std::cout << "You are deep in the woods, a big spider appears!" << std::endl;
	else if (number == 2)
		std::cout << "You are a coward running back, game over!" << std::endl;
	else
		std::cout << "You fell off the cliff, game over!" << std::endl;
}