#!/bin/bash
LINE=1
even=0
odd=0
while read -r CURRENT_LINE; do
	for word in $CURRENT_LINE; do
			if (($LINE % 2 == 0)); then
				if (($word % 2 == 0)); then
					even=$((even + word))
				fi
			else
				if (($word % 2 == 1)); then
					odd=$((odd + word))
				fi
			fi
	done
	((LINE++))
done < "test.txt"
echo "Even " $even
echo "Odd " $odd