=== KingStrawberry ===

= Start
King: Fetch me some strawberries.
Quickly
*[yes]
~ Event("start Strawberry Quest")
-> END
+ [no]
->END

= Run
King: How long do I have to wait?
->END

= Deliver
King: Do you have them?
*[yes]
~Add_State("strawberry",-5)
King: I will eat them now.
~ Event("Finished Quest")
->END
*[no]
->END

=Eating
King: I am eating, even if my sprite isnt moving.
->END