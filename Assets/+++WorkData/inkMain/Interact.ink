===Interact===
{Help.accept: ->Help_waiting}



=Help
{ty : ->Help}
Jonah: Can you bring me the food?
+(accept)[where?] ->kitchen
+[no] 
->END
=kitchen
Jonah: in the kitchen
->END

=Help_waiting

Jonah: wheres the food?
+[on it]
Jonah: be fast
->END






=ty
Jonah: thank you
->END