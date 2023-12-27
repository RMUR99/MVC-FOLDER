#!/bin/bash
# Ask the user for their name
echo 'What is your message?'
read message
echo 'Adding message .......................'

git add . && git commit -m"$message" && git push origin main