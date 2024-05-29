===Crystal===

=Start
Sir Sir :Just keep going.There is nothing to see here.
~ Event("start Quest")
->END

=Run
~ Event("Finished Quest")
Sir Sir: You found a crystal?
+[yes]->Yes
=Yes
Sir Sir: Can I have it?
+[no]
Sir sir: oh.
->END
