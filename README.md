# Owed

A first-person environmental storytelling game built solo in Unity for the 
Synty 12th Birthday Jam (July 2026). The player searches four zones for 
a debt-collection target, with escalating moral weight and an ending choice.

**[Play on itch.io](https://harborviewgames.itch.io/owed)**

---

## About

Owed drops the player into a world where they're searching for someone 
who owes a debt. Each of the four zones reveals more about who this person 
is and why they disappeared. What starts as a straightforward task becomes 
a question the player has to answer for themselves.

Built with Synty POLYGON asset packs. The jam deadline was missed due to 
overscoping — combining an editor tool, narrative content, and a from-scratch 
character controller simultaneously. The project still produced two genuine 
deliverables: the game itself (posted as a late/unlisted demo) and the 
HarborView GameTools UPM package.

---

## What Was Built

**Population Spawner Editor Tool**
A custom Unity editor tool using ScriptableObjects and a ZoneMarker 
MonoBehaviour with a custom Inspector featuring Populate/Clear buttons. 
Designed to speed up content placement across zones using Synty modular 
assets. This tool was extracted into a reusable UPM package 
(com.lighthouse-productions.gametools) and published to GitHub.

**Zone-Based Exploration**
Four distinct zones built with Synty POLYGON packs, each with its own 
environmental tone and narrative weight. Player navigates between zones 
searching for the target.

**First-Person Controller**
Custom character controller built from scratch — movement, camera, and 
interaction handling.

---

## Built With

- Unity (C#)
- Synty POLYGON Asset Packs
- Custom Editor Tooling (ScriptableObjects, Custom Inspector)

---

## What I Learned

Scope discipline. Tackling a custom editor tool, narrative content across 
four zones, and a from-scratch character controller in a single jam was 
too much. The right call would have been to use an existing controller, 
build one zone well, and ship the tool as the portfolio credential — then 
expand later. The tool survived as a standalone package because it was 
built modularly from the start.

---

## HarborView GameTools Package

The Population Spawner and base character controller were extracted into 
a reusable Unity Package Manager package:

**Package:** com.lighthouse-productions.gametools
**GitHub:** [github.com/verbatimaura64](https://github.com/verbatimaura64)

Install via Unity Package Manager using the git URL.
