#include "stdafx.h"
#include <iostream>
#define string const char*
#define output std::cout
#define input std::cin

int main()
{
	output << "Hallo. Bitte gib deinen Spielernamen ein:\n";
	char internalBuffer[2048];
	input >> internalBuffer;
	if (strlen(internalBuffer) > 30) {
		output << "Spielername zu lang!\n";
		return -1;
	}
	char playerName[30];
	strcpy_s(playerName, internalBuffer);
	output << "Player name: " << playerName << "\n";
	output << "Du bist im Wald aufgewacht, dir ist schwindelig.\n";
	output << "Was moechtest Du tun? 1 fuer rechtsrum, 2 fuer linksrum\n";
	int option;
	do
	{
		input >> option;
		if (option < 1 || option > 2)
			output << "Ungueltige Eingabe, try again motherfucker\n";
		else
			break;
	} while (true);
	if (option == 1)
		output << "Monster hat dich erwischt und gefressen. Du bist tot!\nGame Over, try again!\n";
	else
		output << "Du lebst noch, super. Wenn das Spiel weitergehen soll, fuettere mal den Programmierer!\n";
	return 0;
}