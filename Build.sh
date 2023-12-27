#!/bin/bash
echo 'enter your origin link '
read link 
echo 'Initializating the repo with the link provided '
git init
git commit -m "first commit"
git branch -M main
git remote add origin $link
git push -u origin main

