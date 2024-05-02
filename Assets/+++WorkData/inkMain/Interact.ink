===Interact===
{Help.accept: ->Help_waiting}



=Help
{ty : ->Help}
Can you bring me the food?
+(accept)[where?] ->kitchen
+[no] 
->END
=kitchen
in the kitchen
->END

=Help_waiting
{Get_State("food") and not kitchen : ->ty}
wheres the food?
+[on it]
be fast
->END
+[here]
~Add_State("food",-1)
->ty



=ty
thank you
->END